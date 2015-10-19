'use strict';

angular.module('myApp.viewTestScopes', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/viewTestScopes', {
    templateUrl: 'viewTestScopes/viewTestScopes.html',
    controller: 'viewTestScopesCtrl'
  });
}])

.controller('viewTestScopesCtrl', ['$scope', function ($scope) {
    $scope.data = {
        name: "Adam",
        defaultCity: "London"
    };

    $scope.getCity = function (name) {
        return name == "Adam" ? $scope.data.defaultCity : "Unknown";
    }
    
}]);