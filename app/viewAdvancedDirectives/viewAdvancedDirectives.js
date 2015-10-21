'use strict';

angular.module('myApp.viewAdvancedDirectives', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/viewAdvancedDirectives', {
    templateUrl: 'viewAdvancedDirectives/viewAdvancedDirectives.html',
    controller: 'viewAdvancedDirectivesCtrl'
  });
}])

.controller('viewAdvancedDirectivesCtrl', ['$scope', 'data', function ($scope, data) {
    $scope.data = data;
    $scope.theViewFormat = 'ss'
}]);