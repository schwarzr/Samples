import * as tslib_1 from "tslib";
import { Injectable } from "@angular/core";
import { ProjectClient } from '../../src/service/service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
var ProjectService = /** @class */ (function () {
    function ProjectService(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
        this.projects = [];
        router.events
            .pipe(filter(function (e) { return e instanceof NavigationEnd; }))
            .subscribe(function (p) {
            return console.log('title', p.url);
        });
    }
    Object.defineProperty(ProjectService.prototype, "current", {
        get: function () {
            return this._current;
        },
        set: function (value) {
            this._current = value;
            var url = this.getNavUrl(value.displayString);
            this.router.navigateByUrl('/' + url);
        },
        enumerable: true,
        configurable: true
    });
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
    ProjectService.prototype.getNavUrl = function (newProject) {
        var root = this.router.routerState.snapshot.root;
        while (root.firstChild) {
            root = root.firstChild;
        }
        var items = root.pathFromRoot;
        return items.map(function (p) { return (p.routeConfig && p.routeConfig.path == ':project') ? newProject : p.url.join('/'); }).filter(function (p) { return p; }).join('/');
    };
    ProjectService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [ProjectClient, ActivatedRoute, Router])
    ], ProjectService);
    return ProjectService;
}());
export { ProjectService };
//# sourceMappingURL=project.service.js.map