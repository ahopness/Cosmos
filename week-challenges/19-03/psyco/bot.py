# This example requires the 'message_content' intent.

import discord

import api_token

import random
import lyrics

intents = discord.Intents.default()
intents.message_content = True

client = discord.Client(intents=intents)

@client.event
async def on_ready():
    print(f'We have logged in as {client.user}')

@client.event
async def on_message(message):
    if message.author == client.user:
        return

    if ("estranho" in message.content) or ("estranha" in message.content):
        await message.channel.send("ESTRANHO?? CREEP? TOMA UMA LETRA DO RADIO CABEÇA: \n\n" + random.choice(lyrics.creep))
    if "fantasma" in message.content:
        await message.channel.send("FANTASMA?? GHOST OF YOU?? TOMA UMA LETRA DE MEU ROMANCE QUIMICO: \n\n" + random.choice(lyrics.ghostofyou))
    if "codigo" in message.content:
        await message.channel.send("CODIGO?? DECODE?? TOMA UMA LETRA DE PARAMORE: \n\n" + random.choice(lyrics.decode))


client.run(api_token.DISCORD_API_TOKEN)
