import * as tslib_1 from "tslib";
import { Injectable } from "@angular/core";
import { ProjectClient } from '../../src/service/service';
var ProjectService = /** @class */ (function () {
    function ProjectService(service) {
        this.service = service;
        this.projects = [];
    }
    ProjectService.prototype.initialize = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var _a;
            return tslib_1.__generator(this, function (_b) {
                switch (_b.label) {
                    case 0:
                        _a = this;
                        return [4 /*yield*/, this.service.getProjects().toPromise()];
                    case 1:
                        _a.projects = _b.sent();
                        this.current = this.projects[0];
                        return [2 /*return*/];
                }
            });
        });
    };
    ProjectService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [ProjectClient])
    ], ProjectService);
    return ProjectService;
}());
export { ProjectService };
//# sourceMappingURL=project.service.js.map