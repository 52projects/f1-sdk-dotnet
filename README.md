## Recent Update

Started outlining the Groups Realm in order to grab groups and add members to groups

# FellowshipOne REST API for .NET

Fellowship One provides a simple HTTP-based API for a lot of the features. Learn more at [http://developer.fellowshipone.com][0]

### Adding FellowshipOne libraries to your .NET project

The best and easiest way to add the FellowshipOne libraries to your .NET project is to use the NuGet package manager.

#### With Visual Studio IDE

From within Visual Studio, you can use the NuGet GUI to search for and install the Twilio NuGet package. Or, as a shortcut, simply type the following command into the Package Manager Console:

    Install-Package FellowshipOne.Api

#### With .NET Core Command Line Tools

If you are building with the .NET Core command line tools, then you can run the following command from within your project directory:

    dotnet add package FellowshipOne.Api

### Sample Usage

The examples below show how to do simple actions for each realm within the Fellowshipone Api

### Authorization
The FellowshipOne Api uses OAuth for impersonation. The end result is an F1OAuthTicket that holds the access token and secret which will need to be used to create a rest client. There are two different ways to do authorization depending upon the party type the Api client application is.

##### Second Party
Second party api keys can use username and password authorization to get an access token and access token secret.
```csharp
    var ticket = new F1OAuthTicket {
        ConsumerKey = <CONSUMER_KEY>,
        ConsumerSecret = <CONSUMER_SECRET>,
        ChurchCode = <F!_CHURCH_CODE
    };
    
    ticket = RestClient.Authorize(ticket, username, password, loginType);
```
##### Third Party
For third party Api clients, authorization happens by going through the three legged dance of OAuth.
```csharp
    public async Task<IActionResult> GetRequestToken() {
        var ticket = new F1OAuthTicket {
            ConsumerKey = <CONSUMER_KEY>,
            ConsumerSecret = <CONSUMER_SECRET>,
            ChurchCode = <F!_CHURCH_CODE
        };
        
        // Get the an unauthorized request token
        var ticket = RestClient.GetRequestToken(ticket);
        
        var callbackUrl = "/F1CallBack";
        
        // create the login url to send to F1
        var authUrl = RestClient.CreateAuthorizationUrl(ticket, callbackUrl);   
        
        // Redirect to the F1 api Login Screen
        return new RedirectResult(authUrl);
    }
    
    // After successful login at F1, exchange the request token 
    // for an access roken at the callback url
    public async Task<IActionResult> F1CallBack(string oauth_token) {
        var ticket = new F1OAuthTicket {
            ConsumerKey = <CONSUMER_KEY>,
            ConsumerSecret = <CONSUMER_SECRET>,
            ChurchCode = <F!_CHURCH_CODE,
            AccessToken = oauth_token
        };
        
        // exchange the oath token for an access token and secret
        // The access token and secret that is returned are needed for all other requests
        ticket = RestClient.ExchangeRequestToken(ticket);
    }
```

### Realms
Fellowship One has broken up the Api into Realms to seaparate the feature sets. Each realm is also broken up in the SDK to help find relevant endpoints.

### Running Tests
The best way to understand how the SDK works is to look at the test project. The test project has tests for all endpoints of the F1 API. In order to run tests
set up a credentials.config file with the settings below. Currently the App.config file needs to be configured with an absolute path on where the credentials.config file is

```csharp
<appSettings>
	<add key="FellowshipOne.Is.Staging" value="false" />  
	<add key="Consumer.Key" value="" />
	<add key="Consumer.Secret" value="" />
	<add key="Church.Code" value="" />
	<add key="UserName" value="" />
    <add key="Password" value="" />
	<add key="Test.Individual.ID" value="" />
</appSettings>
```

