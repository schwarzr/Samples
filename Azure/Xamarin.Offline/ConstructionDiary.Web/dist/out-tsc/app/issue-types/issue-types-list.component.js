import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
import { IssueClient } from '../../service/service';
var IssueTypesListComponent = /** @class */ (function () {
    function IssueTypesListComponent(service) {
        this.service = service;
    }
    IssueTypesListComponent.prototype.ngOnInit = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var data;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.getIssueTypeListItems().toPromise()];
                    case 1:
                        data = _a.sent();
                        this.items = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    IssueTypesListComponent.prototype.select = function (item) {
        this.selectedItem = item;
    };
    IssueTypesListComponent.prototype.delete = function (item) {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.deleteIssueType(item.id).toPromise()];
                    case 1:
                        _a.sent();
                        return [4 /*yield*/, this.ngOnInit()];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    IssueTypesListComponent = tslib_1.__decorate([
        Component({
            selector: 'issue-types-list',
            templateUrl: './issue-types-list.component.html'
        }),
        tslib_1.__metadata("design:paramtypes", [IssueClient])
    ], IssueTypesListComponent);
    return IssueTypesListComponent;
}());
export { IssueTypesListComponent };
//# sourceMappingURL=issue-types-list.component.js.map