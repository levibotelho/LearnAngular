angular.module('AngularTutorial', []).controller('IndexController', ["$http", function ($http) {
    var self = this;
    self.title = "";
    self.instructions = "";
    self.startingHtml = "";
    self.solutionHtml = "";
    self.startingJavaScript = "";
    self.solutionJavaScript = "";
    self.frameWriteInstructions = [];

    self.setStep = function (id) {
        self.loadStep(id);
    };

    self.loadStep = function (id) {
        $http.get("/Home/GetStep", { params: { id: id } })
        .success(function (data, status, headers, config) {
            self.title = data.Title;
            self.instructions = data.Instructions;
            self.startingHtml = data.StartingHtml;
            self.solutionHtml = data.SolutionHtml;
            self.startingJavaScript = data.StartingJavaScript;
            self.solutionJavaScript = data.SolutionJavaScript;
            self.frameWriteInstructions = data.FrameWriteInstructions;
        })
        .error(function (data, status, headers, config) {
            alert("Error!");
        });
    };
}]);