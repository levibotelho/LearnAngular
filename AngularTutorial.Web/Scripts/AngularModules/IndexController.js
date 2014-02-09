angular.module('AngularTutorial', [])
  .controller('IndexController', ["$http", function ($http) {
      var self = this;
      self.text = "";
      self.startingHtml = "";
      self.solutionHtml = "";
      self.startingJavaScript = "";
      self.solutionJavaScript = "";
      self.frameWriteInstructions = [];

      self.loadStep = function (id) {
          $http.get("/Home/GetStep", { params: { id: id } })
          .success(function (data, status, headers, config) {
              self.text = data.Text;
              self.startingHtml = data.startingHtml;
              self.solutionHtml = data.solutionHtml;
              self.startingJavaScript = data.startingJavaScript;
              self.solutionJavaScript = data.solutionJavaScript;
              self.frameWriteInstructions = data.frameWriteInstructions;
          })
          .error(function (data, status, headers, config) {
              alert("Error!");
          });
      };
  }]);