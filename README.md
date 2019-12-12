<h1>GeoAPI</h1>

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)

<!-- ABOUT THE PROJECT -->
## About The Project
This project is a REST API, working with json as input and output and another API to get, add and remove geolocation data from azure database.

### Built With
* ASP.NET Core WebAPI
* AutoMapper
* Swashbuckle.AspNetCore
* Microsoft.OpenApi

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps:

### Prerequisites
* Docker
* IDE

### Installation

#### For Docker
1. Pull docker container
```sh
docker pull sirvius2122/geolocationapi
```
2. Run container
```sh
docker exec -it <container name> <command>
```

#### For Local
1. Clone the repo
```sh
git clone https://github.com/lukaszszafranski/GeoAPI.git
```

#### For Azure
1. Go to
```sh
https://geolocationapitest.azurewebsites.net/api/Geolocation
```

<!-- USAGE EXAMPLES -->
## Usage
For usage examples please refer to the [Documentation](https://app.swaggerhub.com/apis-docs/lukaszszafranski/GeoAPI/v1)
