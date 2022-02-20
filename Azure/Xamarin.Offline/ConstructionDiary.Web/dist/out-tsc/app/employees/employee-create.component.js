import { __awaiter, __decorate, __generator, __metadata } from "tslib";
import { Component } from "@angular/core";
import { EmployeeClient, EmployeeListItem } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs/operators';
var EmployeeCreateComponent = /** @class */ (function () {
    function EmployeeCreateComponent(service, route, router) {
        var _this = this;
        this.service = service;
        this.route = route;
        this.router = router;
        this.item = new EmployeeListItem();
        route.data.pipe(map(function (p) { return p.project; }))
            .subscribe(function (p) { _this.project = p; });
    }
    EmployeeCreateComponent.prototype.save = function () {
        return __awaiter(this, void 0, void 0, function () {
            var url;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.insert(this.project.id, this.item).toPromise()];
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
    EmployeeCreateComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    EmployeeCreateComponent = __decorate([
        Component({
            selector: 'employee-create',
            templateUrl: './employee-edit.component.html'
        }),
        __metadata("design:paramtypes", [EmployeeClient, ActivatedRoute, Router])
    ], EmployeeCreateComponent);
    return EmployeeCreateComponent;
}());
export { EmployeeCreateComponent };
//# sourceMappingURL=employee-create.component.js.map