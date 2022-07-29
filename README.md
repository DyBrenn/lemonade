# lemonade

Hello and welcome to my lemonade stand :D
Here is a working demo of the app in action https://recordit.co/Zkeq6Nio4Z

# setup backend

For my server I am using https://www.postgresql.org/download/

Once you have the server running you can running you will need to install dotnet ef to update the database `dotnet tool install -g dotnet-ef --version 6.0.0-rc.1`

I have added the database migrations to the repo already so from the project root all you will need to run is `dotnet ef database update --project .`

If for some reason you run into issues you can delete the migrations folder and run this before rerunning the update command `dotnet ef migrations --project . add LemonadeTable`

The last step to run the backend should be `dotnet run` in the project root. (lemonade foler)
I believe restore is run during dotnet run but in case you dont have depenencies run `dotnet restore`

Open https://localhost:7189/ui/altair in browser to view GraphQL interface.

I would reccoment not running any mutations as I have setup the frontend in a way where it will populate the database for you if the query returns nothing.
But if you really want to here is an example mutation to add a drink to the database
```
mutation
{
  createDrink(flavor: "Lemonade", size: "Large", price:1.50)
  {
      id
    flavor
    size
    price
  }
}
```

# setup frontend

First setp you will want to do is navigate to the react project. Run this command from the root folder. `cd react-graphql-client`

To setup frontend react project just install packages using either `npm i` or `yarn install`

To run the react project run `npm run start` or `yarn start`

Open http://localhost:3000 to view it in the browser.
