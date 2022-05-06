import { __awaiter, __decorate, __generator, __metadata } from "tslib";
import { Component } from "@angular/core";
import { EmployeeClient } from '../../service/service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
var EmployeesListComponent = /** @class */ (function () {
    function EmployeesListComponent(service, currentRoute) {
        var _this = this;
        this.service = service;
        currentRoute.data.pipe(map(function (p) { return p.project; }))
            .subscribe(function (p) { _this.project = p; _this.loadData(); });
    }
    EmployeesListComponent.prototype.loadData = function () {
        return __awaiter(this, void 0, void 0, function () {
            var data;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.getEmployeeListItems(this.project.id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.items = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    EmployeesListComponent.prototype.select = function (item) {
        this.selectedItem = item;
    };
    EmployeesListComponent.prototype.delete = function (item) {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.delete(item.id).toPromise()];
                    case 1:
                        _a.sent();
                        return [4 /*yield*/, this.loadData()];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    EmployeesListComponent = __decorate([
        Component({
            selector: 'employees-list',
            templateUrl: './employees-list.component.html'
        }),
        __metadata("design:paramtypes", [EmployeeClient, ActivatedRoute])
    ], EmployeesListComponent);
    return EmployeesListComponent;
}());
export { EmployeesListComponent };
//# sourceMappingURL=employees-list.component.js.map