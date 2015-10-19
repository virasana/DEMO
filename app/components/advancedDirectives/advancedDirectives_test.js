'use strict';

describe('myApp.advancedDirectives module', function() {
  beforeEach(module('myApp.advancedDirectives'));

  describe('advancedDirectives service', function() {
    it('should return current advancedDirectives', inject(function(data) {
      expect(advancedDirectives).toEqual('Hello World!');
    }));
  });
});
