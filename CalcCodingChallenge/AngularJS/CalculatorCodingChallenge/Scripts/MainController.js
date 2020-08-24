(function() {
    var app = angular.module("calcViewer");

    var MainController = function ($scope, calcsvc){

       $scope.clearCalcTxt = function(){
        $scope.calcTxt = "";
       }

        $scope.appendCalcTxt = function(clickTxt){
        $scope.calcTxt += clickTxt;
       }
       $scope.remoteCalcTxt = function(){
           var response = calcsvc.calcTxt($scope.calcTxt)
           response.then( function (remotedata){
                $scope.calcTxt = $scope.calcTxt + " = " + remotedata.data.calcTextAnswer;    
           });
       };
        $scope.username = "angularjs";
        $scope.calcTxt = "";
    };
    app.controller("MainController", MainController);
}());