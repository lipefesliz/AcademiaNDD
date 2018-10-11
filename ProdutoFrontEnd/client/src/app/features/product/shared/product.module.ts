import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { SharedModule } from '../../../shared/shared.module';
import { ProductRoutingModule } from './product-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';

import { ProductCreateComponent } from '../product-create/product-create.component';
import { ProductListComponent } from '../product-list/product-list.component';
import { ProductViewComponent } from '../product-view/product-view.component';
import { ProductDetailComponent } from '../product-detail/product-detail.component';
import { ProductEditComponent } from '../product-edit/product-edit.component';

import { ProductService, ProductResolveService } from './product.service';
import { ProductGridService } from './product-grid.service';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        ProductRoutingModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        ProductCreateComponent,
        ProductListComponent,
        ProductViewComponent,
        ProductDetailComponent,
        ProductEditComponent,
    ],
    providers: [
        ProductService,
        ProductGridService,
        ProductResolveService,
    ],
})
export class ProductModule {
}
