import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { Order, OrderCreateCommand } from '../shared/model/order.model';
import { Subject } from 'rxjs/Subject';
import { OrderService } from '../shared/order.service';

@Component({
    templateUrl: './order-create.component.html',
})
export class OrderCreateComponent implements OnInit, OnDestroy {

    public formModel: FormGroup;

    public order: Order;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private service: OrderService,
        private fb: FormBuilder,
        private router: Router) { }

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
        });
        this.isLoading = false;
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: OrderCreateCommand = new OrderCreateCommand(this.formModel.value);
        this.service.post(cmd).subscribe(() => {
            this.router.navigate(['pedidos']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['pedidos']);
    }
}
