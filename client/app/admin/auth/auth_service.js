(function () {

  function AuthService($resource) {


   
    var self = this;
    self.userInfo={};
    self.authResource = $resource('http://localhost:83\:83/EmployeeService.svc/SignIn/:id', {}, { update: { method: 'PUT' } });


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
            _password: '',
            _isRememberMe:false
      };
      return new self.authResource(user);
    };

    return self;
  }

  angular.module('eli.admin')
    .service('AuthService', ['$resource',AuthService])
}());
      