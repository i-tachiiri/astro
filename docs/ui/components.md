# 📑 UI Components Specification — *Horoscope PDF Generator*

> **ファイル位置**: `docs/ui/components.md`
>
> 画面仕様書（`ui-design.md`）に基づいて **再利用コンポーネント** を定義する *Living Document* です。ここを更新 → 実装／テスト／Storybook 相当のカタログに反映する運用を想定します。
>
> 各セクションの空欄は *仕様未確定* を示すため、PR ベースで必ず埋めてください。

---

## 0. 共通事項

| 項目           | 規約                                               |
| ------------ | ------------------------------------------------ |
| **命名規則**     | PascalCase (例: `PrimaryButton`)                  |
| **フォント**     | Noto Sans JP / M PLUS Rounded 1c                 |
| **カラー**      | ベース `#FFFFFF`, アクセント `#EC407A`, Danger `#E53935` |
| **ライトモード**   | 前提（Dark は backlog）                               |
| **アクセシビリティ** | WCAG AA (コントラスト 4.5:1 以上)                        |

---

## 1. PrimaryButton

### 1.1 Meta

| 項目                 | 値                      |
| ------------------ | ---------------------- |
| **Component Name** | `PrimaryButton`        |
| **Purpose / Role** | メインアクションボタン（保存・ログイン等）  |
| **Usage Context**  | 全画面共通フッタ／フォーム送信／モーダル確定 |

### 1.2 Interface

#### Props

| Prop      | Type                               | Required | Default   | 説明                   |
| --------- | ---------------------------------- | -------- | --------- | -------------------- |
| `text`    | string                             | ✅        | –         | 表示ラベル                |
| `icon`    | Icon?                              | ❌        | null      | 左側アイコン               |
| `isBusy`  | bool                               | ❌        | false     | true ▶ スピナー＋disabled |
| `variant` | enum<br>`default\|danger\|success` | ❌        | `default` | カラーバリエーション           |

#### Events

| イベント名     | Payload | 発火タイミング  |
| --------- | ------- | -------- |
| `onClick` | –       | ユーザクリック時 |

### 1.3 Visual

| 項目             | 内容                                                      |
| -------------- | ------------------------------------------------------- |
| **Size**       | Height 40 px / Min‑Width 100 px / Padding `16 px 24 px` |
| **Radius**     | 6 px                                                    |
| **Responsive** | 幅 ≤ 320 px ▶ アイコン＋省略ラベル (…)                             |
| **Focus Ring** | 2 px outline `#EC407A`                                  |

### 1.4 Behaviour

* `isBusy = true` ▶ Text 隠し・中心にスピナー。再クリック無効。
* `variant = danger` ▶ 背景 `#E53935`, Hover `#C62828`。
* キーボード: `Enter`＝クリック、`Space` 長押し＝リピート無効。

### 1.5 Dependencies

* 下位: `Spinner` (see §9)

### 1.6 Tests & Docs

* Unit: プロパティ反映・イベント発火
* Visual: Verify snapshot (`PrimaryButton_default.png`, `PrimaryButton_busy.png`)

---

## 2. IconButton

*ツールバーや Sync ステータス用の丸型ボタン*

### Meta

| 項目                 | 値                              |
| ------------------ | ------------------------------ |
| **Component Name** | `IconButton`                   |
| **Purpose / Role** | アイコンのみのアクション（設定ギア等）            |
| **Usage Context**  | Dashboard Header, Dialog Close |

### Interface

| Prop       | Type           | Required | Default | 説明          |
| ---------- | -------------- | -------- | ------- | ----------- |
| `icon`     | Icon           | ✅        | –       | 表示アイコン      |
| `tooltip`  | string         | ❌        | ""      | ホバー時テキスト    |
| `size`     | enum `s\|m\|l` | ❌        | `m`     | 24/32/40 px |
| `isActive` | bool           | ❌        | false   | アクティブ状態強調   |

### Visual

* Shape: Circle, Radius 50%
* Size map: s=24 px, m=32 px, l=40 px
* Hover: 背景 `#EC407A` 20% opacity

---

## 3. TextInput

汎用テキストフィールド

### Interface (主要抜粋)

| Prop           | Type   | Required | Default |
| -------------- | ------ | -------- | ------- |
| `value`        | string | ✅        | –       |
| `placeholder`  | string | ❌        | ""      |
| `isError`      | bool   | ❌        | false   |
| `errorMessage` | string | ❌        | ""      |

### Behaviour

* `isError = true` ▶ Border `#E53935`, Tooltip `errorMessage`

---

## 4. DatePicker

BirthDate 用（日付のみ）

### Interface (抜粋)

| Prop           | Type      | Required | Default    |
| -------------- | --------- | -------- | ---------- |
| `selectedDate` | DateTime? | ✅        | null       |
| `minDate`      | DateTime  | ❌        | 1900-01-01 |
| `maxDate`      | DateTime  | ❌        | Now        |

### Visual

* Calendar popup。週開始：Monday。

---

## 5. TimePicker (ClockPicker)

BirthTime 用（時分）

| Prop              | Type      | Required | Default |
| ----------------- | --------- | -------- | ------- |
| `selectedTime`    | TimeSpan? | ✅        | null    |
| `intervalMinutes` | int       | ❌        | 5       |

---

## 6. PlaceAutoCompleteInput

緯度経度検索埋め込み

| Prop              | Type           |
| ----------------- | -------------- |
| `query`           | string         |
| `onPlaceSelected` | (Place) → void |

*実装候補*: Open‑Meteo API or Nominatim

---

## 7. ClientDataGrid

Dashboard 左ペイン

| Prop       | Type                   |
| ---------- | ---------------------- |
| `clients`  | IEnumerable<ClientDto> |
| `onEdit`   | (ClientId) → void      |
| `onDelete` | (ClientId) → void      |

*列*: Name｜BirthDate｜LastReport｜Status

---

## 8. ChartPreviewControl

チャート画像サムネイル + 基本情報

| Prop         | Type        |
| ------------ | ----------- |
| `chartImage` | ImageSource |
| `sunSign`    | string      |
| `moonSign`   | string      |
| `onClick`    | () → void   |

---

## 9. Spinner

共通ローディングインジケータ

| Variant  | Size  | Notes  |
| -------- | ----- | ------ |
| `inline` | 16 px | テキスト横  |
| `block`  | 48 px | モーダル中央 |

---

## 10. ChartGenerateModal

チャート計算進捗

| Prop       | Type       |
| ---------- | ---------- |
| `progress` | double 0‑1 |
| `onCancel` | () → void  |

表示: ProgressBar + メッセージ (`Calculating aspects…` etc.)

---

## 11. ReportSectionCard

PDF レポート編集用の並べ替えカード

| Prop            | Type      |
| --------------- | --------- |
| `sectionTitle`  | string    |
| `isMandatory`   | bool      |
| `onMoveUp/Down` | () → void |

ドラッグハンドル `⋮⋮`、削除不可フラグ

---

## 12. SyncJobStatusDialog

同期ジョブ進捗バー + ログ

| Prop             | Type      |
| ---------------- | --------- |
| `itemsProcessed` | int       |
| `itemsTotal`     | int       |
| `logs`           | string\[] |
| `onClose`        | () → void |

---

## 13. Changelog

| Date       | Author          | Change                                |
| ---------- | --------------- | ------------------------------------- |
| 2025‑06‑15 | ChatGPT (draft) | 初版 — ui‑design.md をもとに主要 13 コンポーネント定義 |
