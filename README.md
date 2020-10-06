
  <h3 align="center">RadioMarket Item Service API</h3>

  <p align="center">
    Item microservice for my e-commerce auction project. 
</p>



## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contact](#contact)



## About The Project

This is an item microservice for an e-commerce wwebsite.

 In a real-world production environment, it may be beneficial to split this solution into discrete read/write endpoints as the number of read operations will significantly outnumber write operations. For the scope of this project, however, it is not feasible to maintain more than one repo per service or repeat code across projects in a solution. Handling of this seperation will then be managed by a load balancer (Traefik, etc.);


### Built With

* ASP .NET Core 3.1
* Entity Framework Core
* Npgsql (EF Core extension)
* Postgres 12


<!-- GETTING STARTED -->
## Getting Started

Prior to setup, you will need the [.Net Core 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1) for your specific platform. .NET Core runtimes are currently available for Windows, OSX, Linux, and certain BSD distros. If you intend to deploy this to IIS, you will also need the hosting bundle (found on the same site).

In addition to .NET Core, you will need a local Postgres instance. These instructions assume that you will be creating a new docker container, but you can skip step 1 if you are using an existing container/instance. It may be helpful to install [pgAdmin](https://www.pgadmin.org/), the graphical manager for Postgres. 

If you are on windows 10, I highly recommend using the WSL2 docker engine as the overall performance is greatly improved over the hyper-v engine by utilizing an actual local linux kernel. The WSL2 setup instructions are [here](https://docs.microsoft.com/en-us/windows/wsl/install-win10), and theWSL2 docker instructions are [here](https://docs.docker.com/docker-for-windows/wsl/)


### Installation

1. Create a postgres container (linux)
```sh
docker run --name radiomarket -p 5432:5432 -e POSTGRES_PASSWORD="YourPWD" -d postgres
```
2. Run The DB migration scripts
```sh
cd ./Database
```
3. Clone the repo
```sh
git clone git@github.com:Jasigler/RadioMarket.ItemService.git
```
4. Build the solution
```sh
cd RadioMarket.Itemservice\Radiomarket.ItemService && dotnet build
```

5. Run the solution
```sh
dotnet run
```



## Usage

Examples of requests and their responses are shown in Postman. Note that the `ItemPath` variable is set to: 'https://localhost:1720'.

** Sample data was generated with [Datanamic](https://www.datanamic.com/). These generated items might not reflect the intended business domain. 


##### Get all items:
![Get all items](https://github.com/Jasigler/RadioMarket.ItemService/blob/master/images/get_all_items.PNG)

##### Get items by id:
![Get an item by ID](https://github.com/Jasigler/RadioMarket.ItemService/blob/master/images/get_item_by_id.PNG)

##### Get items by category:
![Get an item by category](https://github.com/Jasigler/RadioMarket.ItemService/blob/master/images/get_item_by_category.PNG)

##### Get items by owner (user):
![Get an item by owner](https://github.com/Jasigler/RadioMarket.ItemService/blob/master/images/get_item_by_user.PNG)

##### Get items by status:
![Get an item by status](https://github.com/Jasigler/RadioMarket.ItemService/blob/master/images/get_item_by_status.PNG)

##### Create an item:
![Create a new item](https://github.com/Jasigler/RadioMarket.ItemService/blob/master/images/create_item.PNG)



## Roadmap

This is an ongoing project.
See the [open issues](https://github.com/jasigler/Radiomarket.ItemService/issues) for a list of proposed features (and known issues).


## Contact

[@that_sigler](https://twitter.com/that_sigler) - jason.sigler@outlook.com



