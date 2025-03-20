const { Client, Util, DiscordAPIError, Message, Discord } = require('discord.js')
const PREFIX = 'Я'
const client = new Client({ disableEveryone: true })


client.on("Ready", () => {
    console.log(`Oi, ${Client.user.username} o Bot tá online`)


    setInterval(() => {
        const statuses = [
            'TETO - TETOTRIS',
            'Rolling Girl',
            'Leia Umineko'
        ]

        const status = statuses[Math.floor(Math.random() * statuses.length)]
        Client.user.setActivity(status, { type: "LISTING"})

    }, 5000)

});


client.login(process.env.token = '')

