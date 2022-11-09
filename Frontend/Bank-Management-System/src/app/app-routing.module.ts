import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoanComponent } from './components/loan/loan.component';
import { LoginComponent } from './components/login/login.component';
import { MenuComponent } from './components/menu/menu.component';
import { RegisterComponent } from './components/register/register.component';
import { TransactionsComponent } from './components/transactions/transactions.component';
import { ViewComponent } from './components/view/view.component';
import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
  {path:'', component: LoginComponent},
  {path:'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'user/menu', component: MenuComponent, canActivate:[AuthGuard]},
  {path: 'user/loan', component: LoanComponent, canActivate:[AuthGuard]},
  {path: 'user/view', component: ViewComponent, canActivate:[AuthGuard]},
  {path: 'user/transactions', component: TransactionsComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
