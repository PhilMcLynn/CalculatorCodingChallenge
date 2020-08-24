(function(){
    
    var calcsvc = function($http){

      var calcTxt = function calcTxt(calcText) {

        var req = {
            method: 'POST',
            url: 'http://localhost:51301/api/CalcHistory',
            headers: {'Content-Type':'application/json'},
            data: { calcHistoryId: 0, calcText: calcText, calcTextAnswer: '', sourceIPAddress: ''}
           };
        
        return $http(req);  
        }
              
      return { calcTxt: calcTxt};
        
    };
    
    var module = angular.module("calcViewer");
    module.factory("calcsvc", calcsvc);
    
}());