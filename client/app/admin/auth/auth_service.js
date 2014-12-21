(function () {

  function AuthService($resource) {


   
    var self = this;
    self.userInfo={};
    self.authResource = $resource('http://localhost:82\:82/EmployeeService.svc/SignIn/:id', {}, { update: { method: 'PUT' } });


    self.get = function(auth_id){
      return self.authResource.get({id:auth_id },function(d) {
              self.w=d;
             // console.log(self.w)
              });
    };



     self.setUserInfo = function(userInfo){

        self.userInfo=userInfo;
    };
    self.getUserInfo = function(userInfo){
      return self.userInfo;
    };
    self.create = function(){
      var user = {_userId: '',
        _password: ''
      };
      return new self.authResource(user);
    };

    self.query = function (){
      return self.authResource.query();
    };

      self.load= function() {
      return $http.get('/api/v1/auth');
    }
      self.logout= function() {
      return $http.get('/api/v1/auth/logout');
    }
    self.login= function(inputs) {
      return inputs.$save(function(){
        console.log("sss")
      });
    }
    self.register= function(inputs) {
      return $http.post('/api/v1/auth/register', inputs);
    }
    self.locations= function() {
      return $http.get('/api/v1/auth/locations');
    }
    self.check= function() {
      return $http.get('/api/v1/auth/check');
    }











    return self;
  }

  angular.module('eli.admin')
    .service('AuthService', ['$resource',AuthService])
}());
      