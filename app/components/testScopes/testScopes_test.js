'use strict';

describe('myApp.testScopes module', function() {
  beforeEach(module('myApp.testScopes'));

  describe('testScopes service', function() {
    it('should return current testScopes', inject(function(data) {
      expect(testScopes).toEqual('Hello World!');
    }));
  });
});
