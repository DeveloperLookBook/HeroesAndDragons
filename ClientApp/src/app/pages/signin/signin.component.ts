import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CommandFactoryService } from 'src/app/commands/command-factory.service';
import { IResponseError } from 'src/app/repositories/iresponse-error';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  error: IResponseError;

  constructor(
    private commandFactory: CommandFactoryService) {
  }

  onSubmit(form: NgForm) {
    this.commandFactory
        .createSigninCommand({ name: form.value.name })
        .execute()
        .catch(error => this.error = error);
  }

  ngOnInit() {
  }
}
