import { Component, OnInit } from '@angular/core';
import { CommandFactoryService } from 'src/app/commands/command-factory.service';
import { SignupCommand } from 'src/app/commands/signup-command';
import { NgForm } from '@angular/forms';
import { IResponseError } from 'src/app/repositories/iresponse-error';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  error: IResponseError = null;

  constructor(private commandFactory: CommandFactoryService) { }

  onSubmit(form: NgForm): void {
    this.commandFactory
        .createSignupCommand({ name: form.value.name })
        .execute()
        .catch  (error => this.error = error);
  }

  ngOnInit() {

  }

}
