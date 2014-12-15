(function () {

  function AuthService($resource) {


   
    var self = this;
     self.authResource =$resource('http://localhost:81\:81/Employee.svc/SignIn/:id',{},{update: {method: 'PUT'}});


    self.get = function(auth_id){
      return self.authResource.get({id:auth_id },function(d) {
              self.w=d;
              console.log(self.w)
              });
    };




    self.create = function(){
      var user = {UserId: 'sariaaaa',
        Password: 'sariaaaa'
      };
      return new self.authResource(user);
    };

    self.query = function (){
      return self.authResource.query();
    };

    return self;
  }

  angular.module('eliApp')
    .service('AuthService', ['$resource',AuthService])
}());
      