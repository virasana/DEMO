'use strict';

angular.module('myApp.advancedDirectives.advancedDirectives-directive', [])

.directive('advancedDirectives', ['data', function(data) {

    return {
        templateUrl: 'components/advancedDirectives/advancedDirectivesTemplate.html',
        scope: {
            nameprop: "=",
            local: "=nameprop",
            cityFn: "&city"
        }
    }   
}]);
