Teamified Local Event Planner & RSVP Tracker Backend

This Application is created in .Net Core using visual studio 2022 IDE , Followed a Clean architecture with repository pattern and used sqlite as database. Have simple Unit test to test the services.
Runs on : https://localhost:7038/api

<pre>
<h3>Instructions</h3>
1. Make sure that its running on  https://localhost:7038/api
   launchSettings.json  : "applicationUrl": "https://localhost:7038;http://localhost:5000",
2. Make sure Frontend runs on http://localhost:5174
   Program.cs -- CORS Config :   policy.WithOrigins("http://localhost:5174")
   Fronend  vite.config.js :     server: {port: 5174,}
3. Backend Target Framework is .NET 8.0
  </pre>

<strong> Clean Architecture  : </strong> Divided the application into 4 main concepts API,Application,Core and Infrastructure
<ul>
  <li><strong>API : </strong> Entry point of the application, Configured CORS policy middleware here in order for the frontend to access the endpoints.</li>
  <li><strong>Application : </strong> This layer will handle the business logic.Services are stored here that is being called by the controller, Services has their own Interfaces to implement Dependency Injection and promote a loosely 
  coupled code. Dtos are also stored here to avoid too much data exposure.Extension methods are also created to help with formatting time and converting dtos to model and vice versa. </li>
  <li><strong>Core : </strong> This layer holds the database entities blueprints that will be created in the Database(Sqlite). Interfaces of the Repositories also stored here. </li>
  <li><strong>Infrastructure : </strong> Data migrations,database operations and DbContext are stored here. Project uses Entity Framework code first approach to create the schema of the database and also to perform CRUD operations.</li>
  <li><strong>Test : </strong> Unit test for services.</li>
</ul>
     


<pre>  
     <h3>Auth Controller</h3>
        Has only 1 enpoint "login" , only returns the supplied username just to simulate doing API call upon login on UI.
  
     <h3>Event Controller</h3>
        Implemented constructor injection for the required service

     <strong>[HttpGet("GetEvents")] -  GetEvents(int size, int page)</strong>
         <i>Getting all events that is not in the past. Pagination ready but still not implemented on frontend</i>
  
     <strong>[HttpGet("GetEventsByUserAsync/{user}")] -GetEventByUserAsync([FromRoute] string user,int size, int page)</strong>
         <i>Getting all events that is not in the past filtered by username. Pagination ready but still not implemented on frontend</i>

     <strong>[HttpGet("GetEventsByIdAsync/{id}")] - GetEventByIdAsync([FromRoute] int id)</strong>
         <i>Getting single event by ID</i>

     <strong>[HttpPost("AddEvent")] - AddEventAsync([FromBody] CreateEventDto eventDto)</strong>
         <i>Creating an event</i>
         <i>Model is validated through if (!ModelState.IsValid) using Annotations</i>
         <i>Dto for creating event is being used and will be converted into model in the services</i>

     <strong>[HttpDelete("DeleteEvent/{id}")] - DeleteEventAsync([FromRoute] int id)</strong>
         <i>Deleting an event by Id</i>

     <strong>[HttpPut("UpdateEvent")] - UpdateEventAsync([FromBody] UpdateEventDto eventDto)</strong>
         <i>Updating an event by Id</i>
         <i>Model is validated through if (!ModelState.IsValid) using Annotations</i>
         <i>Dto for Updating event is being used and will be converted into model in the services</i>

     <strong>[HttpPatch("ProcessReservation")] - ProcessReservation([FromBody] ReservationRequestDto reservationRequestDto)</strong>
         <i>Processing an event</i>
         <i>Used Patch since we only updating 2 columns</i>
         <i>return NoContent()</i>

    Validations for items that does not exist happens on services and will return a KeyNotFoundException($"Event with ID {id} not found."). Can be used in logging 
    but not currently used in frontend. Have a common error message on toast.    
</pre>



<strong>Items to Improve/Implement</strong>
1. Unit Test
2. Implementation of Fluent Validation
3. Authorization Using JWT Token to implement [Authorize] attribute

     
