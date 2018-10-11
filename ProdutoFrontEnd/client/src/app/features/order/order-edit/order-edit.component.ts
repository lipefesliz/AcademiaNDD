import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Order, OrderEditCommand } from '../shared/model/order.model';
import { Product } from './../../product/shared/model/product.model';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';

import { OrderResolveService, OrderService } from '../shared/order.service';
import { ProductQueryService } from '../../product/shared/product.service';

@Component({
    templateUrl: './order-edit.component.html',
})
export class OrderEditComponent implements OnInit, OnDestroy {

    public products: Product[];

    public formModel: FormGroup;

    public order: Order;

    public isLoading: boolean;

    public data: any;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: OrderResolveService,
        private service: OrderService,
        private fb: FormBuilder,
        private router: Router,
        private productQueryService: ProductQueryService) { }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel = this.fb.group({
            id: [''],
            customer: ['', Validators.required],
            quantity: ['', Validators.required],
            productName: ['', Validators.required],
            total: ['', Validators.required],
            productId: ['', Validators.required],
        });
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((order: Order) => {
                this.order = Object.assign(new Order(), order);
                this.formModel.patchValue(this.order);
            });
    }

    public onAutoCompleteChange(value: string): void {
        Observable.of(value)
          // tslint:disable-next-line:no-magic-numbers
          .delay(300)
          .do((value: any) => {
            this.productQueryService.getAll(value);
          })
          .switchMap((value: any, index: number) => this.productQueryService)
          .subscribe((response: any) => {
            // tslint:disable-next-line:no-console
            console.log(response);
            this.data = response;
          });
      }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: OrderEditCommand = new OrderEditCommand(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['pedidos']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['pedidos']);
    }
}
