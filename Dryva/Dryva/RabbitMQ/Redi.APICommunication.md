## **Documentation of Redi.APICommunication**

This package helps for API communication in multi-service architecture.

**It involves 5 levels for configuration:**

***Level 1:***

Add connection to configuration/appsettings file

    "rabbit": {
    
	    "UserName": "guest",
	    
	    "Password": "guest",
	    
	    "HostName": "localhost",
	    
	    "VHost": "/",
	    
	    "Port": 4000
    
    }

***Level 2:***

    public  void ConfigureServices(IServiceCollection services)
    {    
	    // Configure Rabbit settings.    
	    services.AddRabbit(Configuration);    
    }

***Level 3:***

The thought process of RabbitMQ is pubsub.

The subscriber class will inherit from RabbitSubcriberBase

    public  class  RouteRabbitScriber : RabbitSubcriberBase
    {
	    public  RouteRabbitScriber(IRabbitManager manager):base(manager)
	    {
		    manager.Subscribe<RouteDTO>(“Device_Route”, “Route_Updated”, (model) =>
		    {
		    // perform your update there using the model
		    });
		    }
    }

***Level 4:***

Register the subscriber class with rabbit engine.

   

     public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {        
	        app.RegisterRabbitSubscriber<RouteRabbitScriber, IDeviceCommandRepository>();        
        }

***Level 5:***

The publisher need to have the object of the rabbitManager

    public  RoutesController(IRabbitManager rabbitmanager)
    {
	    this.rabbitmanager = rabbitmanager;    
    }

    // PUT: api/Routes/5    
       [HttpPut("{id}")]    
       public  async Task<int> Put(Guid id, [FromBody] RouteDTO value)    
       {    
   	    // Do your updte here    
   	    rabbitmanager.Publish<RouteDTO>(value, “Device_Route”, “Device_Route”, “Route_Updated”, null);    
   	    //return your object;    
       }

