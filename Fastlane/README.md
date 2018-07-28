fastlane documentation
================
# Installation

Make sure you have the latest version of the Xcode command line tools installed:

```
xcode-select --install
```

Install _fastlane_ using
```
[sudo] gem install fastlane -NV
```
or alternatively using `brew cask install fastlane`

# Available Actions
### clean
```
fastlane clean
```
Create an .ipa for enterprise deployment
### test
```
fastlane test
```

### build
```
fastlane build
```
Create an .ipa (defaults to enterprise build)
### build_staging
```
fastlane build_staging
```
Create an .ipa for enterprise deployment
### build_production
```
fastlane build_production
```
Create an .ipa for app store deploymentclear
### deploy
```
fastlane deploy
```
Deploy .ipa to source (defaults to staging)
### deploy_all
```
fastlane deploy_all
```
Deploy iOS and Android to S3
### deploy_ios
```
fastlane deploy_ios
```
Deploy iOS to S3
### deploy_android
```
fastlane deploy_android
```
Deploy Android to S3
### deploy_production
```
fastlane deploy_production
```
Deploy .ipa to App Store
### version
```
fastlane version
```
Get Version Number
### slacktest
```
fastlane slacktest
```
Test slack message
### staging_all
```
fastlane staging_all
```
Run entire staging workflow
### staging_ios
```
fastlane staging_ios
```
Run entire staging workflow
### staging_android
```
fastlane staging_android
```
Run entire staging workflow
### production
```
fastlane production
```
Run entire production workflow

----

This README.md is auto-generated and will be re-generated every time [fastlane](https://fastlane.tools) is run.
More information about fastlane can be found on [fastlane.tools](https://fastlane.tools).
The documentation of fastlane can be found on [docs.fastlane.tools](https://docs.fastlane.tools).
