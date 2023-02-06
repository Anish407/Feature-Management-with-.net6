Feature Management 
1. Install Microsoft.FeatureManagement.AspNetCore
2. Use the IFeatureManager to get values from the feature management settings
3. IFeatureManager expects features to be inside an object called "FeatureManagement" in one of the config providers
4. Based on the flag we can remove the property if it has its default value

Feature Gate
1. Add the FeatureGate attribute to the controller/method.
2. Add a setting that can be used to toggle the value inside appsettings
3. if the value is false then we get a 404 status code

Custom Filters
1. We can configure the feature to be based on a non boolean value. Ex: for a percentage of calls
(PercentFilter, check program.cs or a time frame )
https://github.com/microsoft/FeatureManagement-Dotnet/blob/main/README.md#Built-in-Feature-Filters
https://github.com/microsoft/FeatureManagement-Dotnet
