'use strict';

angular.module('myApp.testScopes.testScopes-directive', [])

.directive('testScopes', ['data', function(data) {

    return {
        templateUrl: 'components/testScopes/testScopesTemplate.html',
        scope: {
            local: "=nameprop",
            cityFn: "&city"
        }
    }   
}]);
