﻿using Newtonsoft.Json.Linq;
using OpenFin.Notifications.Constants;
using System;
using System.Threading.Tasks;
using Fin = Openfin.Desktop;

namespace OpenFin.Notifications
{
    public class NotificationClient
    {   
        private static Fin.Runtime RuntimeInstance;
        private static Fin.ChannelClient ChannelClient;

        public static event EventHandler NotificationClicked;
        public static event EventHandler NotificationButtonClicked;
        public static event EventHandler NotificationClosed;

        public static void Initialize()
        {
            Initialize(new Uri(NotificationConstants.ServiceManifestUrl));
        }

        public static void Initialize(Uri manifestUri)
        {
            var runtimeOptions = Fin.RuntimeOptions.LoadManifest(manifestUri);

            var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
            var productAttributes = entryAssembly.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), true);

            if(productAttributes.Length > 0)
            {
                runtimeOptions.UUID = ((System.Reflection.AssemblyProductAttribute)productAttributes[0]).Product;
            }
            else
            {
                runtimeOptions.UUID = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            }

            RuntimeInstance = Fin.Runtime.GetRuntimeInstance(runtimeOptions);
            RuntimeInstance.Connect(() =>
            {
                var notificationsService = RuntimeInstance.CreateApplication(runtimeOptions.StartupApplicationOptions);

                notificationsService.isRunning(ack =>
                {
                    if (!(bool)(ack.getData() as JValue).Value)
                    {
                        notificationsService.run();
                    }

                    ChannelClient = RuntimeInstance.InterApplicationBus.Channel.CreateClient(NotificationConstants.ServiceChannelName);

                    ChannelClient.RegisterTopic<object, object>(NotificationTopicConstants.NotificationClicked, OnNotificationClicked);
                    ChannelClient.RegisterTopic<object, object>(NotificationTopicConstants.NotifciationButtonClicked, OnNotificationButtonClicked);
                    ChannelClient.RegisterTopic<object, object>(NotificationTopicConstants.NotificationClosed, OnNotificationClosed);

                    ChannelClient.Connect();
                });
            });
        }

        private static object OnNotificationClicked(object state)
        {
            NotificationClicked?.Invoke(null, EventArgs.Empty);
            return null;
        }
        private static object OnNotificationButtonClicked(object state)
        {
            NotificationButtonClicked?.Invoke(null, EventArgs.Empty);
            return null;
        }
        private static object OnNotificationClosed(object state)
        {
            NotificationClosed?.Invoke(null, EventArgs.Empty);
            return null;
        }

        public async static Task<NotificationOptions> Create(string id, NotificationOptions options)
        {
            //HACK: Change protocol flattening
            options.ID = id;
            var result =  (await ChannelClient?.Dispatch<object>(NotificationConstants.CreateNotification, options)) as JObject;
            return result.ToObject<NotificationOptions>();            
        }

        public async static Task<bool> Clear(string id)
        {
            return  Convert.ToBoolean(await ChannelClient?.Dispatch<object>(NotificationConstants.ClearNotifications, new { id = id })) ;            
        }

        public async static Task<NotificationOptions[]> GetAll()
        {
            var result = (await ChannelClient?.Dispatch<object>(NotificationConstants.GetAppNotifications, new JObject()));
            
            if (result != null)
                return (result as JArray).ToObject<NotificationOptions[]>();
            else
                return null;
        }

        public async static Task<int> ClearAll()
        {
            var result =  (await ChannelClient?.Dispatch<object>(NotificationConstants.ClearAppNotifications, JValue.CreateUndefined())) as JObject;
            return result.ToObject<int>();
        }

        public static Task ToggleNotificationCenter()
        {
            return ChannelClient?.Dispatch<object>(NotificationConstants.ToggleNotificationCenter, JValue.CreateUndefined());
        }
    }
}