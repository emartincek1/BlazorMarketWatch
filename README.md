# Market Watch

Market Watch is a Blazor Server Application for analyzing and exploring stock data.



## Features

Ticker with market movers from the previous trading day

Search stocks with autocomplete by either stock ticker or company name

Shortcuts for popular stocks and stocks mentioned that day on the popular subreddit WallStreetBets

Details on a stock including its currency, exchange, mic code, and type of stock

Data from the last several days, weeks, or months are shown on the chart and represented on a line graph

Arrow to show high-level performance breakdown. (Calculated by close price minus open price)

Recent news with links to articles that apply to that specific stock

Ability to Log In or Register an account

Users have access to a "Stock Watch" which acts as a shortcut page to get to the stock users add to their own watch

Users can add a phone number to the account, change their password, and delete the account


## Installation

Clone down repo, Nuget Install, Set Up Sql Server, Add correct connection string, Run Migration, Have Fun!


## Issues

Heavily reliant on free APIs so not scalable at all, and can even be an issue for one user who uses it for extended periods or makes too many requests too quickly
