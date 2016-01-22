# OneMoreThing
API Response Experiments. Allows experiments to change the inbound and outbound body.

Load a test object using the file a store loader like https://github.je-labs.com/tom-harris/Just.OneMoreThing/blob/master/src/Just.OneMoreThing.Loader/ThingFileLoader.cs

The format of the JSON is as below. 
````
[{
      "end" : "11/20/2015",
      "inbound" : false,
      "name" : "outbound-example",
      "script" : "Body.testproperty1 = true",
      "start" : "11/15/2015",
      "uri" : "/getexample"
   }
]
````

##OWIN Middleware

````c
 IThingLoader loader = new YouImplementationOfALoader();
 appBuilder.Use<Middleware.OneMoreThing>(loader);
````
