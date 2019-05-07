import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
import { EmployeeClient } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs/operators';
var EmployeeEditComponent = /** @class */ (function () {
    function EmployeeEditComponent(service, route, router) {
        var _this = this;
        this.service = service;
        this.route = route;
        this.router = router;
        route.data.pipe(map(function (p) { return p.project; }))
            .subscribe(function (p) { _this.project = p; _this.loadData(); });
    }
    EmployeeEditComponent.prototype.loadData = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var id, data;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        id = this.route.snapshot.params['id'];
                        return [4 /*yield*/, this.service.getEmployeeListItem(id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.item = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    EmployeeEditComponent.prototype.save = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var url;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.update(this.item).toPromise()];
                    case 1:
                        _a.sent();
                        url = this.getNavUrl(this.route);
                        return [4 /*yield*/, this.router.navigateByUrl(url)];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    EmployeeEditComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    EmployeeEditComponent = tslib_1.__decorate([
        Component({
            selector: 'employee-edit',
            templateUrl: './employee-edit.component.html'
        }),
        tslib_1.__metadata("design:paramtypes", [EmployeeClient, ActivatedRoute, Router])
    ], EmployeeEditComponent);
    return EmployeeEditComponent;
}());
export { EmployeeEditComponent };
//# sourceMappingURL=employee-edit.component.js.map