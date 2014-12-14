'use strict';


  angular.module('web1App', [
  'ngCookies',
  'ngResource',
  'ui.router'
])
  .config(function ($stateProvider, $urlRouterProvider,$resourceProvider) {
    //delete $httpProvider.defaults.headers.common['X-Requested-With'];
    
    $urlRouterProvider.otherwise('/');
    $stateProvider
      .state('index', {
        url: '/',
        templateUrl: 'client/app/views/main.html',
        controller:'MainCtrl'
      })
  })




