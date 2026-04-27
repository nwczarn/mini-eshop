param appName string
param location string = 'westeurope'
param environment string

resource plan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: '${appName}-plan'
  location: location
  sku: {
    name: 'F1'
    tier: 'Free'
  }
}

resource app 'Microsoft.Web/sites@2022-03-01' = {
  name: appName
  location: location

  properties: {
    serverFarmId: plan.id
    httpsOnly: true

    siteConfig: {
      appSettings: [
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: environment
        }
      ]
    }
  }
}