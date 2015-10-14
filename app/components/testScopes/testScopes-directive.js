'use strict';

angular.module('myApp.testScopes.testScopes-directive', [])

.directive('testScopes', ['data', function(data) {
  return function(scope, elm, attrs) {
    elm.text(data);
  };
}]);
