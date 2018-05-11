# AWS Lambda

[Available AWS Event Sources](https://docs.aws.amazon.com/lambda/latest/dg/invoking-lambda-function.html)

## Example Lambda Applications

- [ETL Jobs](https://s3.amazonaws.com/awslambda-reference-architectures/extract-transform-load/lambda-refarch-etl.pdf)
- [File Processing](https://s3.amazonaws.com/awslambda-reference-architectures/file-processing/lambda-refarch-fileprocessing.pdf)
- [Data Ingestion](https://s3.amazonaws.com/awslambda-reference-architectures/web-app/lambda-refarch-webapp.pdf)
- [Stream Processing](https://s3.amazonaws.com/awslambda-reference-architectures/stream-processing/lambda-refarch-streamprocessing.pdf)

---

## DotNet CLI

A .NET Core Lambda deployment package is a zip file of your function's compiled assembly along with all of its assembly dependencies. The package also contains a proj.deps.json file. This signals to the .NET Core runtime all of your function's dependencies and a proj.runtimeconfig.json file, which is used to configure the .NET Core runtime.

---

### Setup

**AWS configuration**
1. Create an AWS account
2. Configure the AWS CLI - [Instructions](https://docs.aws.amazon.com/cli/latest/userguide/installing.html)

**DotNet CLI Setup**

1. Install the DotNet CLI - [Available installers](https://github.com/dotnet/core-setup#daily-builds)
2. Add the AWS lambda dotnet cli templates:<br />
```sh
dotnet new -i Amazon.Lambda.Templates::\*
```
3. Verify you have the updated templates:<br />
```sh
dotnet new -all
```
4. View the available options for a lambda-based WebApi:<br />
```sh
dotnet new lambda.AspNetCoreWebAPI --help
```

---

### Usage

1. Create a new WebApi project:
```sh
dotnet new serverless.AspNetCoreWebAPI -n <ProjectName>
```
2. Move to the Project root
```sh
cd <ProjectName>/src/<ProjectName>
```
3. Build the project:
```sh
dotnet build
```
4. Deploy the application:
```sh
dotnet lambda deploy-serverless
```
5. Delete the AWS resources:
```sh
dotnet lambda delete-serverless <CloudformationStackName>
```
