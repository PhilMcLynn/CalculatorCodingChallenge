(function(){
    
    var app = angular.module("calcViewer", ["ngRoute"]);
    
    app.config(function($routeProvider){
        $routeProvider
            .when("/main", {
                templateUrl: "main.html",
                controller: "MainController"
            })
            .otherwise({redirectTo:"/main"});
    });
    
}());