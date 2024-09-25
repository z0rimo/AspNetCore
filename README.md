# Zolab.AspNetCore
This repository hosts a collection of ASP.NET Core-specific NuGet packages designed to provide flexible and powerful authentication mechanisms. These packages can be used individually or combined to build comprehensive authentication solutions.

## Overview
The `AspNetCore` branch is structured to offer a base authentication package and additional provider-specific packages that extend the base functionality.

## Packages
### 1. Zolab.AspNetCore.Authentication.OAuth
- A base package providing core OAuth functionalities.
- **Purpose**: Simplifies the integration of OAuth-based authentication in ASP.NET Core applications.
- **Extensions**: This package can be extended by additional provider-specific packages, such as `kakao` and `naver`.

## Installation
Each package can be installed individually via NuGet. For example:

For OAuth base package:
```
dotnet add package Zolab.AspNetCore.Authentication.OAuth
```

## Usage
### 1. Using the OAuth Base Package
This package provides core functionalities for OAuth authentication. It's designed to be extended by provider-specific packages.

```
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Zolab.AspNetCore.Authentication.OAuth.Extensions;

public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        // Authentication configuration
    })
    .AddOAuth("ProviderName", options =>
    {
        // Base OAuth configuration
        options.ClaimActions.MapJsonThirdKey("custom-claim", "jsonKey", "subKey", "thirdKey");
    });
}
```

## Contributing
Contributions are welcome! If you have ideas for additional features or new authentication providers, feel free to submit a pull request or open an issue.

## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/z0rimo/AspNetCore/blob/main/LICENSE) file for details.
