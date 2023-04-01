# Repro sample

readme.md

*   Issue #9234

    *   AddAppAction icons don't work with MauiImages in the Resources/Images folder on Android #9234

        *   https://github.com/dotnet/maui/issues/9234

    *   PR #

        *   

            *   

```csharp
.ConfigureEssentials
	(
		essentials =>
		{
			essentials
				.AddAppAction
					(
						"notes",
						"Notes",
						"Notes",
						"si_ballot.png"	// will not be rendered
					)
				.AddAppAction
					(
						"chat",
						"Chat",
						"Chat",
						"si_chat"		// rendered
					)
				.OnAppAction(App.HandleAppActions);
		}
	);
```

On Android icons with extension will NOT be rendered:

![Android AppActiopns](./docs/images/Screenshot%202023-03-27%20at%2016.16.17.png)

On iOS icons with extension will be rendered:

![iOS AppActiopns](./docs/images/Screenshot%202023-03-27%20at%2016.07.32.png)


## TODOs
