angular.module('AngularTutorial', ["ui.ace"]).controller('IndexController', ["$http", function ($http, initialId) {
    var self = this;
    self.html = "";
    self.javaScript = "";
    self.title = "";
    self.instructions = "";
    self.startingHtml = "";
    self.solutionHtml = "";
    self.startingJavaScript = "";
    self.solutionJavaScript = "";
    self.frameWriteInstructions = [];

    self.run = function () {
        var doc = window.frames[0].document;
        doc.open();
        doc.write("<html><body>");
        doc.write(self.html);
        doc.write("<script>");
        doc.write(self.javaScript);
        doc.write("<\/script><\/body><\/html>");
        doc.close();
    };

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

    self.setStep(initialId);
}]);