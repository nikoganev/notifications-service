# Contributing to OpenFin Notifications

Thank you for your interest in contributing to [HadoukenIO Notifications Service](https://github.com/HadoukenIO/). Default behaviors of a project like Notifications Service greatly benefit from the opinions and contributions of the community.

Following these guidelines will expedite any changes you propose by providing clarity around both the goals of the service and the development process.

# Contributions
## Ground Rules
* This project uses [Google TypeScript Style](https://www.npmjs.com/package/gts). Successfully run `npm run fix` before making a pull request (this will run gts).
* If your change would update either this guide or the README, include relevant changes in your PR.

## Getting started
To build the project locally, follow the steps in the README [here](https://github.com/HadoukenIO/notifications-service#run-locally).
1. Create your own fork of the code
2. Do the changes in your fork
3. If you like the change and think the project could use it:
    * Be sure you have followed the code style for the project.
    * Sign the FINOS Contributors License Agreement available [here](https://www.finos.org/governance)
	* If you are working on behalf of an organization, your employer must sign the CLA.
    * Send a pull request indicating that you have a CLA on file.

# Contributor License Agreement (CLA)
A CLA is a document that specifies how a project is allowed to use your
contribution; they are commonly used in many open source projects.

**_All_ contributions to _all_ projects hosted by [FINOS](https://www.finos.org/)
must be made with a
[Foundation CLA](https://finosfoundation.atlassian.net/wiki/spaces/FINOS/pages/83034172/Contribute)
in place, and there are [additional legal requirements](https://finosfoundation.atlassian.net/wiki/spaces/FINOS/pages/75530375/Legal+Requirements)
that must also be met.**

_NOTE:_ Commits and pull requests to FINOS repositories will only be accepted from those contributors with an active, executed Individual Contributor License Agreement (ICLA) with FINOS OR who are covered under an existing and active Corporate Contribution License Agreement (CCLA) executed with FINOS. Commits from individuals not covered under an ICLA or CCLA will be flagged and blocked by the FINOS Clabot tool. Please note that some CCLAs require individuals/employees to be explicitly named on the CCLA.

*Need an ICLA? Unsure if you are covered under an existing CCLA? Email [help@finos.org](mailto:help@finos.org)*

## How to report a bug

 When filing an issue, make sure to answer these five questions:

 1. What operating system and processor architecture are you using?
 2. What version of node are you using?
 3. What did you do?
 4. What did you expect to see?
 5. What did you see instead?

Add your issue to the repository issues.

## Roadmap

The project README includes the current [roadmap](https://github.com/HadoukenIO/notifications-service#roadmap)

## Issues

The project README inlcudes a list of [known issues](https://github.com/HadoukenIO/notifications-service#known-issues). Other issues can found in the [issues tab](https://github.com/HadoukenIO/notifications-service/issues).

# How to suggest a feature or enhancement

Before suggesting an improvement, please see the README for current roadmap items and known issues.

The goal of this project is to provide robust notification management as an out of the box solution for applications running on OpenFin. Feature requests are welcome and should include rational.

# Contributing Pull Requests (Code & Docs)
To make review of PRs easier, please:

 * Please make sure your PRs will merge cleanly - PRs that don't are unlikely to be accepted.
 * For code contributions, follow the existing code layout.
 * For documentation contributions, follow the general structure, language, and tone of the [existing docs](https://github.com/HadoukenIO/notifications-service/wiki).
 * Keep commits small and cohesive - if you have multiple contributions, please submit them as independent commits (and ideally as independent PRs too).
 * Reference issue #s if your PR has anything to do with an issue (even if it doesn't address it).
 * Minimise non-functional changes (e.g. whitespace).
 * Ensure all new files include a header comment block containing the [Apache License v2.0 and your copyright information](http://www.apache.org/licenses/LICENSE-2.0#apply).
 * If necessary (e.g. due to 3rd party dependency licensing requirements), update the [NOTICE file](https://github.com/HadoukenIO/notifications-service/blob/master/NOTICE) with any new attribution or other notices

## Commit and PR Messages

* **Reference issues, wiki pages, and pull requests liberally!**
* Use the present tense ("Add feature" not "Added feature")
* Use the imperative mood ("Move button left..." not "Moves button left...")
* Limit the first line to 72 characters or less