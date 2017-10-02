# GDAX DotNet API
A .NET Standard library for GDAX.

## Contributing
All contributions must be checked into their own branch, containing only work related to a single feature or bug. When the work is ready to be merged to main, and meets all definitions of done, you can create a pull request which will then be reviewed to make sure all unit tests are passing.

### Definition of Done
1. All code must be unit tested with passing unit tests
2. All code must meet the coding guidelines
3. All public interfaces and public POCO classes must be fully documented with meaningful documentation

## Running Tests
To run the unit tests, you will need to:
1. login to https://public.sandbox.gdax.com/ and create an api key.
2. Open an elevated command prompt
3. Navigate to the test directory (Gdax.Tests)
4. Run the following commands, replacing the tokens with your api key values. (If you prefer, you can alternatively create environment variables instead)
```
dotnet user-secrets set GdaxCredentials:ApiKey "[API_KEY]"
dotnet user-secrets set GdaxCredentials:Passphrase "[PASSPHRASE]"
dotnet user-secrets set GdaxCredentials:Secret "[SECRET]"
```

Once this is done, you should be able to run the unit tests without any issue. If at some point most of the tests start failing it could be because the sandbox environment got reset so you will need to follow these steps again.

## Tips are appreciated!

- **BTC**: 196JGgN3jGJTBoZkF1F2o68gJys81W9wss
- **ETH**: 0x3764f75fe970d7dbc50066b9ae1cc926ad1f8ad2
- **LTC**: LYHCMRoEc6jHHPDktmSE8ZMm3XYR1vSSGp
- **ZEC**: t1fVDvSJnvnxhRN7jD2SARqLc8k66xzNDBF
