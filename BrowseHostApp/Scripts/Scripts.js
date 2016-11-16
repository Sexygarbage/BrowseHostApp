var app = angular
.module("browseHostApp",[])
.controller("valuesController", ['$scope', '$http', '$log', function ($scope, $http, $log) {

    
    $scope.$log = $log;
    $scope.list = $http({
        method: "GET",
        url: "http://localhost:2498/api/values"
    })
    .jsonp();
    


    $scope.pick = function (register) {
        register.name = 'c:\\'
    };
}]);