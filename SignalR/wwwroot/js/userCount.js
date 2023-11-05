//create connection
var connectionUserCount = new signalR.HubConnectionBuilder()
    //.configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .withUrl("/hubs/userCount", signalR.HttpTransportType.WebSockets).build();
//Connect to methods that hub invokes aka receives notifications from hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
})


connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
})

//Invoke hub methods aka send notification to hub

function newWindowLoadedOnClient() {
    connectionUserCount.invoke("NewWindowLoaded", "Siam").then((value) => console.log(value));
}
//start connection

function fulfilled() {
    //Do something
    console.log("Connection to user hub successful");
    newWindowLoadedOnClient();
}
function rejected() {
    //do something
    console.log("Connection to user hub rejected");

}
connectionUserCount.start().then(fulfilled, rejected);