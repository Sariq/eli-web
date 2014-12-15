(function () {
  function MainCtrl(MainService) {
    var self = this;
    console.log(MainService);

  }

  angular.module('eliApp')
    .controller('MainCtrl', ['MainService',MainCtrl]);
}());
