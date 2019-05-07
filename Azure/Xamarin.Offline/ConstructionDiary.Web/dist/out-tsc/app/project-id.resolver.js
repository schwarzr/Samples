import * as tslib_1 from "tslib";
import { ProjectClient } from '../../src/service/service';
import { ProjectService } from './project.service';
import { Injectable } from '@angular/core';
var ProjectIdResolver = /** @class */ (function () {
    function ProjectIdResolver(service, projectService) {
        this.service = service;
        this.projectService = projectService;
    }
    ProjectIdResolver.prototype.resolve = function (route, state) {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var projectName, project;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        projectName = route.params.project;
                        return [4 /*yield*/, this.service.getProjectByName(projectName).toPromise()];
                    case 1:
                        project = _a.sent();
                        if (this.projectService.current.id != project.id) {
                            this.projectService.current = project;
                        }
                        return [2 /*return*/, project];
                }
            });
        });
    };
    ProjectIdResolver = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [ProjectClient, ProjectService])
    ], ProjectIdResolver);
    return ProjectIdResolver;
}());
export { ProjectIdResolver };
//# sourceMappingURL=project-id.resolver.js.map