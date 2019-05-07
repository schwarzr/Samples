import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { ProjectService } from './project.service';
var AppComponent = /** @class */ (function () {
    function AppComponent(projectService) {
        this.projectService = projectService;
        this.isCollapsed = true;
    }
    AppComponent.prototype.ngOnInit = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.projectService.initialize()];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    AppComponent.prototype.selectProject = function (projectid) {
        this.projectService.current = this.projectService.projects.filter(function (p) { return p.id == projectid; })[0];
    };
    AppComponent = tslib_1.__decorate([
        Component({
            selector: 'app-root',
            templateUrl: './app.component.html',
            styles: []
        }),
        tslib_1.__metadata("design:paramtypes", [ProjectService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map