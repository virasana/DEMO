'use strict';

angular.module('myApp.advancedDirectives.advancedDirectives-directive', [])

.directive('advancedDirectives', ['$interval', 'dateFilter', 'data', function ($interval, dateFilter, data) {
    console.log(data.length);

    function link(scope, element, attrs) {
        var format,
            timeoutId;


        attrs.$observe('advancedDirectives', function (theFormat) {
            format = theFormat;
            console.log('format changed: ' + format);
            updateTime();
        });

    element.on('$destroy', function () {
        $interval.cancel(timeoutId);
    });


    // start the UI update process; save the timeoutId for canceling
    timeoutId = $interval(function () {
        updateTime(); // update DOM
    }, 1000);

    function updateTime() {
        scope.directiveScope2 = dateFilter(new Date(), format);
        console.log('updateTime: ' + format + dateFilter(new Date(), format));
    }
}

    var theScope = {
        directiveScope1: '@info',
        directiveScope2: '@advancedDirectives'

    }

return {
    templateUrl: 'components/advancedDirectives/advancedDirectivesTemplate.html',
    scope: theScope,
    link: link
}
}]);
