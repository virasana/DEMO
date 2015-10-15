'use strict';

angular.module('myApp.viewTestScopes', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/viewTestScopes', {
    templateUrl: 'viewTestScopes/viewTestScopes.html',
    controller: 'viewTestScopesCtrl'
  });
}])

.controller('viewTestScopesCtrl', ['$scope', function ($scope) {
    $scope.theData = {
        name: 'Jean-Pierre',
        calculateSomething: function () {
            return 'banana';
        }
    };
    
}]);