import {Settings} from '../../../model/Settings';
import {IDatastore} from '../IDatastore';

import {Repository, ReturnResult, VoidResult} from './Repository';

/**
 * @class A class that represents the settings table in the datastore
 */
export class SettingsRepository extends Repository<Settings> {
    /**
     * @class Constructor
     * @param {IDatastore} datastore The low leve database layer
     */
    constructor(datastore: IDatastore<Settings>) {
        super(datastore, 'settings');
    }

    /**
     * @function getTableName return the table name
     * @returns {string} The name of the table
     * @public
     */
    public get getTableName() {
        return super.getTableName;
    }

    /**
     * @function create Creates the settings in the database
     * @param {Settings} setting The settings to be saved
     * @public
     * @returns {Promise<ReturnResult>} Success message and value return back to calling client
     */
    public async create(setting: Settings): Promise<ReturnResult<Settings>> {
        const settings = await this.genericGetAll();

        if (!settings.success) {
            return {success: false, errorMsg: settings.errorMsg, value: null};
        }

        if (settings.success && settings.value.length === 1 && this.instanceOf(settings.value[0])) {
            return {success: false, errorMsg: 'There are already settings saved', value: null};
        }

        return super.genericCreate(setting);
    }

    /**
     * @function getAll Gets the settings in the database
     * @public
     * @returns {Promise<ReturnResult>} Success message and value return back to calling client
     */
    public async get(): Promise<ReturnResult<Settings>> {
        const result = await super.genericGetAll();

        if (!result.success || result.value.length < 1) {
            return {success: false, errorMsg: 'There were no settings to be found', value: null};
        } else {
            return {success: true, value: result.value[0]};
        }
    }

    /**
     * @function remove Removes settings from the settings store
     * @public
     * @returns {Promise<ReturnResult>} Success message and value return back to calling client
     */
    public async remove(): Promise<VoidResult> {
        return super.genericRemoveAll();
    }

    /**
     * @function update Updates the settings in the settings store
     * @param updatedSettings The updated settings
     * @public
     * @returns {Promise<ReturnResult>} Success message and value return back to calling client
     */
    public async update(updatedSettings: Settings): Promise<ReturnResult<Settings>> {
        return super.genericUpdate(updatedSettings);
    }

    /**
     * @function instanceOf This is used as a user defined type guard
     * @param {any} object The object we are checking
     * @returns {}
     */
    private instanceOf(object: Settings|string): object is Settings {
        return (object as Settings).id !== undefined;
    }
}
