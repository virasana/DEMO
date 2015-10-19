'use strict';

describe('myApp.testScopes module', function() {
  beforeEach(module('myApp.testScopes'));

  describe('app-testScopes directive', function() {
    it('should print current testScopes', function() {
      module(function($provide) {
        $provide.value('data', 'Goodbye World!');
      });
      inject(function($compile, $rootScope) {
        var element = $compile('<span test-scopes></span>')($rootScope);
        expect(element.text()).toEqual('Goodbye World!');
      });
    });
  });
});
